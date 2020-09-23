using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Certificate;
using Microsoft.Extensions.DependencyInjection;

namespace kakao
{
    public static class AuthHandler
    {
        public static void AddCsCertificateAuthentication(this IServiceCollection services)
        {
            services.AddAuthentication(CertificateAuthenticationDefaults.AuthenticationScheme)
              .AddCertificate(op =>
              {
                  op.Events = new CertificateAuthenticationEvents
                  {
                      OnCertificateValidated = c => Validator(c),
                  };
              });
        }

        private static Task Validator(CertificateValidatedContext context)
        {
            PerformValidation(context);
            return Task.CompletedTask;
        }

        private static void PerformValidation(CertificateValidatedContext context)
        {
            string subject = context.ClientCertificate.Subject;
            string pid;
            int closing = subject.LastIndexOf(')');
            int opening = subject.LastIndexOf('(', closing - 1);

            if (opening <= -1)
            {
                context.Fail("No PID provided.");
            }

            pid = subject.Substring(opening + 1, closing - opening - 1);

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, pid, ClaimValueTypes.String, context.Options.ClaimsIssuer)
            };

            context.Principal = new ClaimsPrincipal(new ClaimsIdentity(claims, context.Scheme.Name));
            context.Success();
        }
    }
}

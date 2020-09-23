using HotChocolate.Types;
using HotChocolate.Types.Relay;

namespace kakao
{
    public class WeatherForecastQueryType : ObjectTypeExtension<WeatherForecastQueries>
    {
        protected override void Configure(IObjectTypeDescriptor<WeatherForecastQueries> descriptor)
        {
            descriptor.Name(nameof(Query));

            descriptor.Field(t => t.WeatherForecasts())
                .Type<ListType<NonNullType<WeatherForecastType>>>()
                .UsePaging<WeatherForecastType>()
                .UseFiltering();
        }
    }
}

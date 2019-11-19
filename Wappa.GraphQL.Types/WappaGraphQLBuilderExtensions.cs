using GraphQL.Server;
using Microsoft.Extensions.DependencyInjection;

namespace Wappa.GraphQL.Types
{
    public static class WappaGraphQLBuilderExtensions
    {
        public static IGraphQLBuilder AddWappaGraphTypes(
            this IGraphQLBuilder builder,
            ServiceLifetime serviceLifetime = ServiceLifetime.Singleton)
        {
            return builder.AddGraphTypes(typeof(WappaGraphQLBuilderExtensions).Assembly, serviceLifetime);
        }
    }
}

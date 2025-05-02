using System.Reflection;
using AutoMapper;

namespace Mriguel.Application.Mappings
{
    /// <summary>
    /// AutoMapper profile for the application layer
    /// </summary>
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            ApplyMappingsFromAssembly(Assembly.GetExecutingAssembly());
        }
        
        private void ApplyMappingsFromAssembly(Assembly assembly)
        {
            var types = assembly.GetExportedTypes()
                .Where(t => t.GetInterfaces().Any(i => 
                    i.IsGenericType && (
                        i.GetGenericTypeDefinition() == typeof(IMapFrom<>) ||
                        i.GetGenericTypeDefinition() == typeof(IMapTo<>))))
                .ToList();
                
            foreach (var type in types)
            {
                var instance = Activator.CreateInstance(type);
                
                var methodInfo = type.GetMethod("Mapping") 
                    ?? type.GetInterface("IMapFrom`1")?.GetMethod("Mapping")
                    ?? type.GetInterface("IMapTo`1")?.GetMethod("Mapping");
                    
                methodInfo?.Invoke(instance, new object[] { this });
            }
        }
    }
    
    /// <summary>
    /// Interface for mapping from a source type
    /// </summary>
    /// <typeparam name="T">Source type</typeparam>
    public interface IMapFrom<T>
    {
        void Mapping(Profile profile) => profile.CreateMap(typeof(T), GetType());
    }
    
    /// <summary>
    /// Interface for mapping to a destination type
    /// </summary>
    /// <typeparam name="T">Destination type</typeparam>
    public interface IMapTo<T>
    {
        void Mapping(Profile profile) => profile.CreateMap(GetType(), typeof(T));
    }
}

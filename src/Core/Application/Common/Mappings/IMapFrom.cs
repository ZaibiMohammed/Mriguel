using AutoMapper;

namespace Mriguel.Application.Common.Mappings
{
    /// <summary>
    /// Interface for AutoMapper configuration
    /// </summary>
    public interface IMapFrom<T>
    {
        /// <summary>
        /// Creates the mapping configuration
        /// </summary>
        void Mapping(Profile profile) => profile.CreateMap(typeof(T), GetType());
    }
}

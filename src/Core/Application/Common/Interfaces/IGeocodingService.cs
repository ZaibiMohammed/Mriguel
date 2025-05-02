using Mriguel.Domain.ValueObjects;

namespace Mriguel.Application.Common.Interfaces
{
    /// <summary>
    /// Interface for geocoding service operations
    /// </summary>
    public interface IGeocodingService
    {
        /// <summary>
        /// Geocodes an address to coordinates
        /// </summary>
        Task<GeocodingResult> GeocodeAddressAsync(string address, string city, string postalCode, string country);
        
        /// <summary>
        /// Reverse geocodes coordinates to an address
        /// </summary>
        Task<GeocodingResult> ReverseGeocodeAsync(double latitude, double longitude);
        
        /// <summary>
        /// Searches for locations by text
        /// </summary>
        Task<IEnumerable<GeocodingResult>> SearchLocationsAsync(string searchText, int limit = 5);
    }
    
    /// <summary>
    /// Represents a geocoding result
    /// </summary>
    public class GeocodingResult
    {
        /// <summary>
        /// Location with address and coordinates
        /// </summary>
        public Location Location { get; set; }
        
        /// <summary>
        /// Formatted address
        /// </summary>
        public string FormattedAddress { get; set; }
        
        /// <summary>
        /// Place ID
        /// </summary>
        public string PlaceId { get; set; }
    }
}

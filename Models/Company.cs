using System.ComponentModel.DataAnnotations;

namespace VehicleTrafficManagement.Models
{
    public class Company
    {
        [Key]
        public int CompaniesId { get; set; }

        [Required]
        public string Name { get; set; }

        public string TradeName { get; set; }

        public string TaxNumber { get; set; }

        public int CompanyInformationId { get; set; }

        public CompanyInformation CompanyInformation { get; set; }

        public int CompanyRelated { get; set; }
    }
}

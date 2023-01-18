using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Etherscan.Commands.Token
{
    #pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    public class TokenCreateUpdateRequest
    {
        public int Id { get; set; }

        [Required]
        [StringLength(5, ErrorMessage = "Symbol length can't be more than 5.")]
        public string Symbol { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Symbol length can't be more than 50.")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Total Supply")]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "Total Supply must be number")]
        [Range(1, 9999999999999999.99, ErrorMessage = "Total Supply must be between 1 and 9999999999999999.99")]
        [DisplayFormat(DataFormatString = "{0:#.####}", ApplyFormatInEditMode = true)]
        [Column(TypeName = "decimal(18, 0)")]
        public decimal? TotalSupply { get; set; }

        [Required]
        [Display(Name = "Contract Address")]
        [StringLength(66, ErrorMessage = "Contract Address length can't be more than 66.")]
        public string ContractAddress { get; set; }

        [Required]
        [Display(Name = "Total Holders")]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "Total Holders must be number")]
        [Range(1, 9999999999999999.99, ErrorMessage = "Total Holders must be between 1 and 9999999999999999.99")]
        public int? TotalHolders { get; set; }

        public decimal Price { get; set; }
    }
}
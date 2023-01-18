using Etherscan.Entities;

namespace Etherscan.Models.TokenVM
{
    public class TokenTableVM : Token
    {
        #pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public int Rank { get; set; }
        public decimal TotalSupplyPercent { get; set; }
        public string TotalSuppyStr { get; set; }
    }
}
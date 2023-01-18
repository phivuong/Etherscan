using Etherscan.Entities;

namespace Etherscan.Models.TokenVM
{
    public class TokenDetailVM : Token
    {
        #pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public string TotalSupplyStr { get; set; }
    }
}
using System.ComponentModel;

namespace Etherscan.Models.TokenVM
{
    public class TokenExportVM
    {
        #pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public string Rank { get; set; }
        public string Symbol { get; set; }
        public string Name { get; set; }
        [DisplayName("Contract Address")]
        public string ContractAddress { get; set; }
        [DisplayName("Total Holders")]
        public string TotalHolders { get; set; }
        [DisplayName("Total Supply")]
        public string TotalSupply { get; set; }
        [DisplayName("Total Supply %")]
        public string TotalSupplyPercent { get; set; }
    }
}
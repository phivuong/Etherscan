using Etherscan.Commands.Token;

namespace Etherscan.Models.TokenVM
{
    public class TokenCreateUpdateVM : TokenCreateUpdateRequest
    {
        public bool IsCreateNew { get; set; }
    }
}
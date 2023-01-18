using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Etherscan.Models;
using Etherscan.Services;
using X.PagedList;
using Etherscan.Models.TokenVM;

namespace Etherscan.Controllers;

public class HomeController : Controller
{
    private ITokenService _tokenService;
    private int PageSize = 10;

    public HomeController(ITokenService tokenService)
    {
        _tokenService = tokenService;
    }

    public IActionResult Index(int? p)
    {
        List<TokenTableVM> tableVMs = new List<TokenTableVM>();
        var tokens = _tokenService.GetAll().OrderByDescending(x => x.TotalSupply);
        var sumSupply = tokens.Sum(x => x.TotalSupply);
        int rank = 1;
        foreach (var token in tokens)
        {
            tableVMs.Add(new TokenTableVM()
            {
                Id = token.Id,
                Rank = rank,
                Symbol = token.Symbol,
                Name = token.Name,
                ContractAddress = token.ContractAddress,
                TotalHolders = token.TotalHolders,
                TotalSuppyStr = token.TotalSupply.ToString("N0").Replace(".", ""),
                TotalSupplyPercent = (token.TotalSupply / sumSupply) * 100
            });
            rank++;
        }
        int pageNumber = (p ?? 1);
        var tokensPaging = tableVMs.ToPagedList(pageNumber, PageSize);
        ModelState.Clear();
        return View(tokensPaging);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}


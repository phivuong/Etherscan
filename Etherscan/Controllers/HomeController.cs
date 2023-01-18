using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Etherscan.Models;
using Etherscan.Services;
using X.PagedList;
using Etherscan.Models.TokenVM;
using OfficeOpenXml;
using OfficeOpenXml.Table;

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
        List<TokenTableVM> tableVMs = GetListTokenData();
        int pageNumber = (p ?? 1);
        var tokensPaging = tableVMs.ToPagedList(pageNumber, PageSize);
        ModelState.Clear();
        return View(tokensPaging);
    }

    [HttpPost]
    public IActionResult ExportExcel(IFormCollection obj)
    {
        DateTimeOffset dto = new DateTimeOffset(DateTime.UtcNow);
        string unixTime = dto.ToUnixTimeSeconds().ToString();
        string exportFileName = $"Token_List_{unixTime}.xlsx";
        var list = GetExportTokenData();
        var exportbytes = ExporttoExcel<TokenExportVM>(list, "TokenList");
        return File(exportbytes, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", exportFileName);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    private byte[] ExporttoExcel<T>(List<T> table, string filename)
    {
        using ExcelPackage pack = new ExcelPackage();
        ExcelWorksheet ws = pack.Workbook.Worksheets.Add(filename);
        ws.Cells["A1"].LoadFromCollection(table, true, TableStyles.Light1);
        return pack.GetAsByteArray();
    }

    private List<TokenTableVM> GetListTokenData()
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
                Symbol = token.Symbol,
                Rank = rank,
                Name = token.Name,
                ContractAddress = token.ContractAddress,
                TotalHolders = token.TotalHolders,
                TotalSuppyStr = token.TotalSupply.ToString("N0").Replace(".", ""),
                TotalSupplyPercent = ((token.TotalSupply / sumSupply) * 100).ToString("F5").Replace(",", ".")
            });
            rank++;
        }
        return tableVMs;
    }

    private List<TokenExportVM> GetExportTokenData()
    {
        List<TokenExportVM> tableVMs = new List<TokenExportVM>();
        var tokens = _tokenService.GetAll().OrderByDescending(x => x.TotalSupply);
        var sumSupply = tokens.Sum(x => x.TotalSupply);
        int rank = 1;
        foreach (var token in tokens)
        {
            tableVMs.Add(new TokenExportVM()
            {
                Rank = rank.ToString(),
                Symbol = token.Symbol,
                Name = token.Name,
                ContractAddress = token.ContractAddress,
                TotalHolders = token.TotalHolders.ToString(),
                TotalSupply = token.TotalSupply.ToString("N0").Replace(".", ""),
                TotalSupplyPercent = ((token.TotalSupply / sumSupply) * 100).ToString("F5").Replace(",", ".")
            }) ;
            rank++;
        }
        return tableVMs;
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}


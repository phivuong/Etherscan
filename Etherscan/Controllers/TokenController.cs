using AutoMapper;
using Etherscan.Commands.Token;
using Etherscan.Models.TokenVM;
using Etherscan.Services;
using Microsoft.AspNetCore.Mvc;

namespace Etherscan.Controllers
{
    public class TokenController : Controller
    {
        private ITokenService _tokenService;
        private readonly IMapper _mapper;

        public TokenController(ITokenService tokenService, IMapper mapper)
        {
            _tokenService = tokenService;
            _mapper = mapper;
        }

        public IActionResult Create()
        {
            var vm = new TokenCreateUpdateVM() {
                IsCreateNew = true
            };
            return PartialView("Partial/CreateEditToken", vm);
        }

        public IActionResult Edit(int id)
        {
            var token = _tokenService.GetById(id);
            var vm = _mapper.Map<TokenCreateUpdateVM>(token);
            vm.IsCreateNew = false;
            return PartialView("Partial/CreateEditToken", vm);
        }

        public IActionResult Save(TokenCreateUpdateVM model)
        {
            if (ModelState.IsValid)
            {
                var req = _mapper.Map<TokenCreateUpdateRequest>(model);
                if (model.IsCreateNew)
                    _tokenService.Create(req);
                else
                    _tokenService.Update(req);
                ModelState.Clear();
                return RedirectToAction("Index", "Home");
            }
            return PartialView("Partial/CreateEditToken", model);
        }

        public IActionResult Detail(int id)
        {
            var token = _tokenService.GetById(id);
            var vm = _mapper.Map<TokenDetailVM>(token);
            vm.TotalSupplyStr = token.TotalSupply.ToString("N0").Replace(".", "");
            return View(vm);
        }

        public IActionResult GetChartData()
        {
            var data = new List<TokenChartVM>();
            var tokens = _tokenService.GetAll();
            var sumSupply = tokens.Sum(x => x.TotalSupply);
            foreach (var token in tokens)
            {
                data.Add(new TokenChartVM()
                {
                    Name = token.Name,
                    Y = (token.TotalSupply / sumSupply) * 100
                });
            }
            return Json(data);
        }
    }
}
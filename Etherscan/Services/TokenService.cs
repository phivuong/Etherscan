using AutoMapper;
using Etherscan.Commands.Token;
using Etherscan.Entities;
using Etherscan.Helpers;

namespace Etherscan.Services
{
    public interface ITokenService
    {
        IEnumerable<Token> GetAll();
        Token GetById(int id);
        void Create(TokenCreateUpdateRequest model);
        void Update(TokenCreateUpdateRequest model);
    }

    public class TokenService : ITokenService
    {
        private DataContext _context;
        private readonly IMapper _mapper;

        public TokenService(DataContext context,  IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Create(TokenCreateUpdateRequest model)
        {
            var token = _mapper.Map<Token>(model);
            // save user
            _context.Token.Add(token);
            _context.SaveChanges();
        }

        public IEnumerable<Token> GetAll()
        {
            return _context.Token;
        }

        public Token GetById(int id)
        {
            return getToken(id);
        }

        public void Update(TokenCreateUpdateRequest model)
        {
            var token = getToken(model.Id);
            // copy model to user and save
            _mapper.Map(model, token);
            _context.Token.Update(token);
            _context.SaveChanges();
        }

        #region Helper Methods
        private Token getToken(int id)
        {
            var token = _context.Token.Find(id);
            if (token == null) throw new KeyNotFoundException("User not found");
            return token;
        }
        #endregion
    }
}
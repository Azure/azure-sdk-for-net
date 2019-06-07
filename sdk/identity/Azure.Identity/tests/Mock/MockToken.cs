using System;
using System.Collections.Generic;
using System.Text;

namespace Azure.Identity.Tests.Mock
{
    class MockToken
    {
        private StringBuilder _tokenBuilder;
        private string _token;

        public MockToken()
        {
            _tokenBuilder = new StringBuilder(Guid.NewGuid().ToString() + ";");
        }

        public MockToken(string token)
        {
            _token = token;
            _tokenBuilder = new StringBuilder(token);
        }

        public MockToken WithField(string name, string value)
        {
            if (!string.IsNullOrEmpty(value))
            {
                _tokenBuilder.Append($"{name}={value};");
            }


            return this;
        }

        public bool HasField(string name, string value)
        {
            return Token.Contains($"{name}={value};");
        }


        public override string ToString()
        {
            return Token;
        }

        public string Token
        {
            get
            {
                if (_token == null || _token.Length != _tokenBuilder.Length)
                {
                    _token = _tokenBuilder.ToString();
                }

                return _token;
            }
        }
    }
}

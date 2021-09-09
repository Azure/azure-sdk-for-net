(function() {
  window.authProvider = 'aad'; // aad, microsoftaccount, google, facebook, twitter
  window.apiBaseUrl = 'https://<your function name>.azurewebsites.net';

  let authToken = ""
  if (window.location.hash) {
    const match = window.location.hash.match(/\btoken=([^&]+)/)
    if (match && match[1]) {
      authToken = JSON.parse(decodeURIComponent(match[1])).authenticationToken
      sessionStorage.setItem('authToken', authToken)
      history.pushState("", document.title, window.location.pathname + window.location.search)
    }
  }

  if (!authToken) {
    authToken = sessionStorage.getItem('authToken')
  }

  window.auth = {
    token: authToken,
    loginUrl: window.apiBaseUrl +
      `/.auth/login/${window.authProvider}?session_mode=token&post_login_redirect_url=` +
      encodeURIComponent(window.location.href),
    logout: function() {
      sessionStorage.removeItem('authToken')
      window.location.reload()
    }
  }
}())

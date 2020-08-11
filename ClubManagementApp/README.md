# Install IS4
dotnet new -i IdentityServer4.Templates

##dotnet new is4empty -n <name/companyname>.IDP
##dotnet new is4ef -n <name/companyname>.IDP
##dotnet new is4id -n <name/companyname>.IDP
##dotnet new is4ui -n <name/companyname>.IDP

#ENDPOINTS
    - Authorize
    Parameters
        - scope : openid profile
        - response_type=(workflow type) :   AuthorizationCode
                                                code
                                            Implicit
                                                id_token 
                                                id_token token
                                            Hybrid
                                                code id_token, code token, code id_token token
        - redirect_uri=http://......



#FLOW
    1 Client    Authentication Request from client => redirection
    2 IDP       Authorization Endpoint : User authenticates (Login, PWD)
    (3 IDP      asks for Consent) Optional
    4 Response with Code from URI
    5 Client requests Token endpoint with Code, ClientId, ClientSecret)
    6 IDP response id_token
    7 Client Validates Token => Claims extraction

#COMMUNICATION TYPES
    - Front Channel
        Information delivered to the browser via URI or Form POST (response_mode)
        => Authorization endpoint
    Back Channel
    - Server to Server (SAFER)
        => Token endpoint
        
#IdentityServer4 (OAuth / OpenIdC)
	- https://jwt.io/
	- https://swagger.io/docs/specification/authentication/openid-connect-discovery/
	- https://developer.okta.com/docs/reference/api/oidc/
	- https://identityserver4.readthedocs.io/en/latest/topics/windows.html
	- https://medium.com/the-new-control-plane/using-active-directory-ad-as-the-repository-for-authentication-with-identityserver4-fa010e0980db

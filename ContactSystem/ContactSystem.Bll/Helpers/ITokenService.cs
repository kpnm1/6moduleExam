﻿using ContactSystem.Bll.DTOs;
using System.Security.Claims;

namespace ContactMate.Bll.Helpers;

public interface ITokenService
{
    public string GenerateTokent(UserGetDto user);
    string GenerateRefreshToken();
    ClaimsPrincipal? GetPrincipalFromExpiredToken(string token);
}
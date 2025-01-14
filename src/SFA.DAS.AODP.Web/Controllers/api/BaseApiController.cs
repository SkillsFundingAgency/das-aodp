﻿using Microsoft.AspNetCore.Mvc;
using SFA.DAS.AODP.Application.MemoryCache;

namespace SFA.DAS.AODP.Web.Controllers;

public class BaseApiController : ControllerBase
{
    protected readonly ICacheManager _cacheManager;

    public BaseApiController(ICacheManager cacheManager)
    {
        _cacheManager = cacheManager;
    }

    protected T GetFromCache<T>(string key)
    {
        return _cacheManager.Get<T>(key);
    }

    protected void SetToCache<T>(string key, T value)
    {
        _cacheManager.Set(key, value);
    }

    protected void RemoveFromCache(string key)
    {
        _cacheManager.Remove(key);
    }
}

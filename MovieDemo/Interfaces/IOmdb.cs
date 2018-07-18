﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieDemo.Interfaces
{
    public interface IOmdb
    {
        string ApiKey { get; }
        string BaseQuery { get; }
        string BaseUrl { get; }
        object QueryTitle(string title);
    }
}
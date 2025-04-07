﻿using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace Peliculas_Api.Utilidades
{
    public  static class HttpContextExtensions
    {
        public async static Task  InsertarParametroPaginacionEnCabecera<T> (this HttpContext httpContext,
            IQueryable <T> queryable)
            {

            if ( httpContext is null)
            {
                throw new ArgumentNullException(nameof(httpContext));

            }
            double cantidad = await queryable.CountAsync();
            httpContext.Response.Headers.Append("cantidad-total-registros", cantidad.ToString());
        }
    }
}

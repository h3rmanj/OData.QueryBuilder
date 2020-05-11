﻿using OData.QueryBuilder.Constants;
using OData.QueryBuilder.Extensions;
using OData.QueryBuilder.Resourses;
using System;
using System.Linq.Expressions;

namespace OData.QueryBuilder.Builders
{
    public class ODataQueryBuilder<TResource> : IODataQueryBuilder<TResource>
    {
        private readonly string _baseUrl;

        public ODataQueryBuilder(Uri baseUrl) =>
            _baseUrl = $"{baseUrl.OriginalString.TrimEnd(ODataQuerySeparators.SlashChar)}{ODataQuerySeparators.SlashString}";

        public ODataQueryBuilder(string baseUrl) =>
            _baseUrl = $"{baseUrl.TrimEnd(ODataQuerySeparators.SlashChar)}{ODataQuerySeparators.SlashString}";

        public IODataQueryResource<TEntity> For<TEntity>(Expression<Func<TResource, object>> entityResource) =>
            new ODataQueryResource<TEntity>($"{_baseUrl}{entityResource.Body.ToODataQuery(string.Empty)}");
    }
}
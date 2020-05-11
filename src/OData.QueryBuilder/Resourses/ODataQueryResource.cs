﻿using OData.QueryBuilder.Constants;
using OData.QueryBuilder.Parameters;
using System.Text;

namespace OData.QueryBuilder.Resourses
{
    public class ODataQueryResource<TEntity> : IODataQueryResource<TEntity>
    {
        private readonly StringBuilder _queryBuilder;

        public ODataQueryResource(string resourceUrl) =>
            _queryBuilder = new StringBuilder(resourceUrl);

        public IODataQueryParameterKey<TEntity> ByKey(int key)
        {
            _queryBuilder.Append($"({key}){ODataQuerySeparators.BeginString}");

            return new ODataQueryParameterKey<TEntity>(_queryBuilder);
        }

        public IODataQueryParameterKey<TEntity> ByKey(string key)
        {
            _queryBuilder.Append($"('{key}'){ODataQuerySeparators.BeginString}");

            return new ODataQueryParameterKey<TEntity>(_queryBuilder);
        }

        public IODataQueryParameterList<TEntity> ByList()
        {
            _queryBuilder.Append(ODataQuerySeparators.BeginString);

            return new ODataQueryParameterList<TEntity>(_queryBuilder);
        }
    }
}

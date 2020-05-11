﻿using OData.QueryBuilder.Constants;
using System;
using System.Collections.Generic;
using System.Text;

namespace OData.QueryBuilder.Parameters
{
    public class ODataQueryParameter : IODataQueryParameter
    {
        protected readonly StringBuilder _queryBuilder;

        public ODataQueryParameter(StringBuilder queryBuilder) =>
            _queryBuilder = queryBuilder;

        public Dictionary<string, string> ToDictionary()
        {
            var odataOperators = _queryBuilder.ToString()
                .Split(new char[2] { ODataQuerySeparators.BeginChar, ODataQuerySeparators.MainChar }, StringSplitOptions.RemoveEmptyEntries);

            var dictionary = new Dictionary<string, string>(odataOperators.Length - 1);

            for (var step = 1; step < odataOperators.Length; step++)
            {
                var odataOperator = odataOperators[step].Split(ODataQuerySeparators.EqualSignChar);

                dictionary.Add(odataOperator[0], odataOperator[1]);
            }

            return dictionary;
        }

        public Uri ToUri() => new Uri(_queryBuilder.ToString().TrimEnd(ODataQuerySeparators.MainChar));
    }
}

﻿using OData.QueryBuilder.Parameters;
using System.Linq.Expressions;

namespace OData.QueryBuilder.ExpressionVisitors
{
    internal class SelectODataExpressionVisitor : ODataExpressionVisitor
    {
        private int _count;

        public SelectODataExpressionVisitor()
            : base()
        {
            _count = default;
        }

        protected override Expression VisitMember(MemberExpression node)
        {
            if (_count != default)
            {
                _queryBuilder.Append(Constants.CommaStringSeparator);
            }

            _count++;

            return base.VisitMember(node);
        }
    }
}
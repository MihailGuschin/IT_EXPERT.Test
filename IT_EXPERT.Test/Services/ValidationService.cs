using AutoMapper.Execution;
using IT_EXPERT.Test.DAL;
using IT_EXPERT.Test.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace IT_EXPERT.Test.Services
{
    public class ValidationService<TEntity> where TEntity : BaseEntity
    {
        private readonly ApplicationContext _dBcontext;
        public ValidationService(ApplicationContext dbContext)
        {
            _dBcontext = dbContext;
        }
        public bool Exist<TValue>(Expression<Func<TEntity, TValue>> property, TValue value)
        {
            var entityType = typeof(TEntity);

            LambdaExpression lambda = property;
            var memberExpression = lambda.Body is UnaryExpression expression
                ? (MemberExpression)expression.Operand
                : (MemberExpression)lambda.Body;

            ParameterExpression arg = (ParameterExpression)memberExpression.Expression;
            ConstantExpression propertyValue = Expression.Constant(value, typeof(TValue));
            BinaryExpression equals = Expression.Equal(memberExpression, propertyValue);
            Expression<Func<TEntity, bool>> selector = Expression.Lambda<Func<TEntity, bool>>(equals, new ParameterExpression[] { arg });
            
            return _dBcontext.Set<TEntity>().Any(selector);
        }
    }
}

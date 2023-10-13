using System;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Reflection;
using Microsoft.AspNetCore.Mvc.ModelBinding;

public static class DescriptionExtensions
{
    public static string GetDescription<TModel, TProperty>(this TModel model, Expression<Func<TModel, TProperty>> expression)
    {
        var memberExpression = (MemberExpression)expression.Body;
        var propertyInfo = (PropertyInfo)memberExpression.Member;
        var descriptionAttribute = propertyInfo.GetCustomAttribute<DescriptionAttribute>();

        return descriptionAttribute?.Description;
    }
}
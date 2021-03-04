using System;
using System.Collections.Generic;
using System.Text;
using Castle.DynamicProxy;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace Core.Utilities.Interceptors
{
    public abstract class MethodInterception:MethodInterceptionBaseAttribute
    {
        protected virtual void OnBefore(IInvocation invocation)  {  }
        protected virtual void OnAfter(IInvocation invocation)  {  }
        protected virtual void OnException(IInvocation invocation, System.Exception e) { }
        protected virtual void OnSuccess(IInvocation invocation) {  }

        public override void Intercept(IInvocation invocation)
        {
            var IsSuccess=true;

            try
            {
                invocation.Proceed();
                OnBefore(invocation);
            }
            catch (Exception e)
            {
                IsSuccess = false;
                OnException(invocation, e);
                throw;
            }
            finally
            {
                if (IsSuccess)
                {
                    OnSuccess(invocation);
                }
                OnAfter(invocation);
            }
        }
    }
}

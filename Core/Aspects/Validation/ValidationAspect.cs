using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Interceptors;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Aspects.Validation
{
    public class ValidationAspect : MethodInterception
    {
        private Type _validatorType;
        public ValidationAspect(Type validatorType)
        {
            if (!typeof(IValidator).IsAssignableFrom(validatorType))
            {
                throw new Exception("Bu bir IValidator sınıfı değil.");
            }

            _validatorType = validatorType;
        }
        protected override void OnBefore(IInvocation invocation) // invocation: gönderilen metod
        {
            var validator = (IValidator)Activator.CreateInstance(_validatorType); // validator'ı CarValidator yaptı.
            var entityType = _validatorType.BaseType.GetGenericArguments()[0]; // Verilen validator'ün generic argümanlarından ilkini alır.
            var entities = invocation.Arguments.Where(t => t.GetType() == entityType); // fonksiyonun parametrelerini tek tek dolaşır. entityType ile aynı olan parametreleri entities'e atar.
            foreach (var entity in entities)
            {
                ValidationTool.Validate(validator, entity);
            }
        }
    }
}

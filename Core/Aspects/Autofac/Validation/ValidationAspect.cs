using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Validation.FluentValidation;
using Core.Utilities.Interceptors;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Aspects.Autofac.Validation
{
    public class ValidationAspect : MethodInterception
    {
        private Type _validatorType;
        public ValidationAspect(Type validatorType)
        {
            if (!typeof(IValidator).IsAssignableFrom(validatorType))//Gönderilen validatorType eğer bir IValıdator değilse hata ver.
            {
                throw new System.Exception("Bu bir doğrulama sınıfı değil");
            }

            _validatorType = validatorType;
        }
        protected override void OnBefore(IInvocation invocation)
        {
            var validator = (IValidator)Activator.CreateInstance(_validatorType);//Reflection.Çalışma anında instance oluştur.
            var entityType = _validatorType.BaseType.GetGenericArguments()[0];//Validator un çalışma tipini bul ve onun generic çalıştığı veri tipini bul(yani car)
            var entities = invocation.Arguments.Where(t => t.GetType() == entityType);//İlgili methodun parametrelerini bak entityType'a(car) denk gelen parametleri bul
            foreach (var entity in entities)//Her birini tek tek gez
            {
                ValidationTool.Validate(validator, entity);//ValidationTool u kullanarak validate et
            }
        }
    }
}

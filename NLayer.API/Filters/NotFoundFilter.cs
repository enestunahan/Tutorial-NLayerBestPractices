using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using NLayer.Core.Dtos;
using NLayer.Core.Models;
using NLayer.Core.Service;

namespace NLayer.API.Filters
{
    public class NotFoundFilter<T> : IAsyncActionFilter where T : BaseEntity
    {
        private readonly IService<T> _service;

        public NotFoundFilter(IService<T> service)
        {
            _service= service;
        }
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var idValue = context.ActionArguments.Values.FirstOrDefault();
            // ilk olan propertydeki ilk değeri al diyoruz 
            
            if(idValue == null)
            {
                // bu değer null ise yoluna devam etsin demekki 
                // bana bir id gelmiyosa herhangi birşeyle karşılaştırmama gerek yok.
                await next.Invoke();
                return;
            }

            var id  = (int)idValue;
            var anyEntity = await _service.AnyAsync(x=> x.Id == id);

            if(anyEntity) 
            {
                // eğerki entity var ise bi sonraki yere gitsin bi işlem yapmasın (aşağıdaki  kodun açıklaması )
                await next.Invoke();
                return;
            }


            context.Result = new NotFoundObjectResult(CustomResponseDto<NoContentDto>.Fail(404, $"{typeof(T).Name}({id}) not found"));
        }
    }
}

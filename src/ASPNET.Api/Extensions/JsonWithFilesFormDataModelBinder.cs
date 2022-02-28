using ASPNET.Api.ViewModels;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Text.Json;

namespace ASPNET.Api.Extensions
{
    public class JsonWithFilesFormDataModelBinder : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            ArgumentNullException.ThrowIfNull(nameof(bindingContext));
            /*if (bindingContext == null)
            {
                throw new ArgumentNullException(nameof(bindingContext));
            }*/

            var serializeOptions = new JsonSerializerOptions
            {
                WriteIndented = true,
                Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
                PropertyNameCaseInsensitive = true
            };

            var produtoImagemViewModel = JsonSerializer.Deserialize<ProdutoImagemViewModel>(bindingContext.ValueProvider.GetValue("produto").FirstOrDefault(), serializeOptions);
            produtoImagemViewModel.ImagemUpload = bindingContext.ActionContext.HttpContext.Request.Form.Files.FirstOrDefault();

            bindingContext.Result = ModelBindingResult.Success(produtoImagemViewModel);
            return Task.CompletedTask;
        }
    }
}

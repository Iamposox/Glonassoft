using GlonasSoft.Application.Exceptions;
using GlonasSoft.BL;

namespace GlonasSoft.Application.Service.Common;

public abstract class GlonasSoftContextService
{
    protected readonly GlonasSoftContext Context;

    protected GlonasSoftContextService(GlonasSoftContext context)
    {
        Context = context;
    }

    protected async Task SaveChangesAsync()
    {
        int result;
        try
        {
            result = await Context.SaveChangesAsync();
        }
        catch (Exception e)
        {
            throw new BadRequestException("Ошибка при попытке сохранения изменений в базу данных", e);
        }

        if (result < 1)
            throw new BadRequestException("Отсутствуют сохраненные изменения");
    }
}

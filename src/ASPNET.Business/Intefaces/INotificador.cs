using System.Collections.Generic;
using ASPNET.Business.Notificacoes;

namespace ASPNET.Business.Intefaces
{
    public interface INotificador
    {
        bool TemNotificacao();
        List<Notificacao> ObterNotificacoes();
        void Handle(Notificacao notificacao);
    }
}
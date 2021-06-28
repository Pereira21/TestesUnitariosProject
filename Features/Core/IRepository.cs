using System;
using System.Collections.Generic;

namespace Features.Core
{
    public interface IRepository<T> where T : Entity
    {
        IEnumerable<T> ObterTodos();
        void Adicionar(T entity);
        void Atualizar(T entity);
        void Remover(Guid id);
        void Dispose();
    }
}

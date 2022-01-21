using ArckDan.MayDay.Repositorio.Context;
using Microsoft.Extensions.Configuration;
using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;

namespace ArckDan.MayDay.Repositorio
{
    public abstract class Connection : IDisposable
    {
        #region atributos

        private bool disposed = false;
        private readonly Component _component = new Component();
        protected IntPtr _handle;        
        protected IConfiguration _configuration;

        [System.Runtime.InteropServices.DllImport("Kernel32")]
        private extern static Boolean CloseHandle(IntPtr handle);

        #endregion

        #region métodos

        /// <summary>
        /// método para abrir a conexão com o banco de dados
        /// </summary>
        protected void AbrirConexao()
        {
            Conn.Open();
        }

        /// <summary>
        /// método utilizado para encerrar a conexão com o banco de dados
        /// </summary>
        protected void EncerrarConexao()
        {
            // encerra a conexão com o banco de dados
            Conn.Close();

            // remove os recursos gerenciáveis e não gerenciáveis na memória
            Dispose(disposing: false);
        }

        /// <summary>
        /// método utilizado para dispensar os recursos presos na memória
        /// </summary>
        public void Dispose()
        {
            // chama o dispose para forçar a limpeza do heap
            Dispose(disposing: true);

            // força a passagem do garbage collector
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// método utilizado para controlar a limpeza dos recursos em memória
        /// </summary>
        protected virtual void Dispose(bool disposing)
        {
            // verifica se o dispose já foi chamado
            if (!disposed)
            {
                // condição para o dispose de recursos gerenciados e não gerenciados
                if (disposing)
                    _component.Dispose();

                // chama os métodos apropriados para limpeza dos recursos não gerenciados
                CloseHandle(_handle);
            }
        }

        #endregion

        #region propriedades

        protected MayDayContext DB => new MayDayContext();

        protected IDbConnection Conn => new SqlConnection(_configuration.GetConnectionString("MayDayDev"));

        #endregion
    }
}
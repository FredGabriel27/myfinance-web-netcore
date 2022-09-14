using myfinance_web_netcore.Infra;
using myfinance_web_netcore.Models;
using System.Data;

namespace myfinance_web_netcore.Domain
{
    public class Transacao
    {
        public List<TransacaoModel> ListaTransacoes()
        {
            List<TransacaoModel> lista = new List<TransacaoModel>();
            var objDal = DAL.GetInstancia;
            objDal.Connectar();

            var sql = "SELECT ID, HISTORICO, TIPO, DATA, VALOR, ID_PLANO_CONTA FROM TRANSACAO";
            var dataTable = objDal.RetornarDataTable(sql);

            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                lista.Add(new TransacaoModel()
                {
                    Id = int.Parse(dataTable.Rows[i]["id"].ToString()),
                    Data = Convert.ToDateTime(dataTable.Rows[i]["data"].ToString()),
                    Valor = Convert.ToDecimal(dataTable.Rows[i]["valor"]),
                    Tipo = dataTable.Rows[i]["tipo"].ToString(),
                    Historico = dataTable.Rows[i]["historico"].ToString(),
                    IdPlanoConta = Convert.ToInt32(dataTable.Rows[i]["id_plano_conta"])
                });
            }
            objDal.Desconnectar();
            return lista;
        }

        public void Inserir(TransacaoModel form)
        {
            DAL dalInstance = DAL.GetInstancia;
            dalInstance.Connectar();

            string sql = @$"INSERT INTO TRANSACAO(DATA, VALOR, TIPO, HISTORICO, ID_PLANO_CONTA) 
                VALUES (
                '{form.Data.ToString("yyyy-dd-MM")}', {form.Valor}, '{form.Tipo}', 
                '{form.Historico}', {form.IdPlanoConta})";

            dalInstance.ExecutarComandoSQL(sql);
            dalInstance.Desconnectar();
        }

        public void Editar(TransacaoModel form)
        {
            DAL dalInstance = DAL.GetInstancia;
            dalInstance.Connectar();

            string sql = @$"UPDATE TRANSACAO SET DATA = '{form.Data.ToString("yyyy-dd-MM")}',
                VALOR = {form.Valor}, TIPO = '{form.Tipo}', HISTORICO = '{form.Historico}', 
                ID_PLANO_CONTA = {form.IdPlanoConta} WHERE ID = {form.Id}";

            dalInstance.ExecutarComandoSQL(sql);
            dalInstance.Desconnectar();
        }

        public void Excluir(int id)
        {
            DAL dal = DAL.GetInstancia;
            dal.Connectar();
            string sql = $"DELETE FROM TRANSACAO WHERE ID = {id}";
            dal.ExecutarComandoSQL(sql);
            dal.Desconnectar();
        }

        public TransacaoModel CarregarTransacaoPorId(int? id)
        {
            DAL dalInstance = DAL.GetInstancia;
            dalInstance.Connectar();

            string sql = $"SELECT ID, DATA, VALOR, TIPO, HISTORICO, ID_PLANO_CONTA FROM TRANSACAO WHERE ID = '{id}'";
            DataTable dataTable = dalInstance.RetornarDataTable(sql);

            TransacaoModel transaction = new TransacaoModel()
            {
                Id = int.Parse(dataTable.Rows[0]["ID"].ToString()),
                Data = DateTime.Parse(dataTable.Rows[0]["data"].ToString()),
                Valor = decimal.Parse(dataTable.Rows[0]["valor"].ToString()),
                Tipo = dataTable.Rows[0]["tipo"].ToString(),
                Historico = dataTable.Rows[0]["historico"].ToString(),
                IdPlanoConta = int.Parse(dataTable.Rows[0]["id_plano_conta"].ToString())
            };

            dalInstance.Desconnectar();

            return transaction;
        }
    }
}

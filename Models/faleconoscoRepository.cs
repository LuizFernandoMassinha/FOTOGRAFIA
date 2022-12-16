using System;
using System.Collections.Generic;
using MySqlConnector;

namespace SITELUMY.Models
{

public class faleconoscoRepository
{
private const string DadosdeConexao = "Database=sitelumy; Data Source=127.0.0.1; User ID=root;";
public void testeconexao()
    {
        MySqlConnection Conexao = new MySqlConnection(DadosdeConexao);
        Conexao.Open();
        //Codigo para conexão com o banco de dados para usar o crud
        Console.WriteLine("Uhuu Conseguimos Logar");

        Conexao.Close(); //usado para fechar a conexão 
    }

    public void inserir(faleconosco f) // inserir um usuario
    {
     MySqlConnection Conexao = new MySqlConnection(DadosdeConexao);
        Conexao.Open();
        string Query = "INSERT INTO entreemcontato (nomeUsuario, emailUsuario, TelefoneUsuario, mensagemdoUsuario) VALUES (@nomeUsuario, @emailUsuario, @TelefoneUsuario, @mensagemdoUsuario)";
        MySqlCommand Comando = new MySqlCommand(Query, Conexao);

        Comando.Parameters.AddWithValue("@nomeUsuario", f.nomeUsuario);
        Comando.Parameters.AddWithValue("@emailUsuario", f.emailUsuario);
        Comando.Parameters.AddWithValue("@TelefoneUsuario", f.TelefoneUsuario);
        Comando.Parameters.AddWithValue("@mensagemdoUsuario", f.mensagemdoUsuario);
        Comando.ExecuteNonQuery();
        Conexao.Close();
    }

        public List<faleconosco> Query()
{
    MySqlConnection conexao = new MySqlConnection(DadosdeConexao);
    conexao.Open();
    string sql = "SELECT * FROM entreemcontato ORDER BY nomeUsuario";
    MySqlCommand comandoQuery = new MySqlCommand(sql, conexao);
    MySqlDataReader reader = comandoQuery.ExecuteReader();
    List<faleconosco> lista = new List<faleconosco>();
    
    while (reader.Read())
    {
      faleconosco fr = new faleconosco();  
        fr.IdUsuario = reader.GetInt32("IdUsuario");
       
        if(!reader.IsDBNull(reader.GetOrdinal("nomeUsuario")))
            fr.nomeUsuario = reader.GetString("nomeUsuario");
       
        if(!reader.IsDBNull(reader.GetOrdinal("emailUsuario")))
            fr.emailUsuario = reader.GetString("emailUsuario");

        if(!reader.IsDBNull(reader.GetOrdinal("TelefoneUsuario")))
            fr.TelefoneUsuario = reader.GetString("TelefoneUsuario");

        if(!reader.IsDBNull(reader.GetOrdinal("mensagemdoUsuario")))
            fr.mensagemdoUsuario = reader.GetString("mensagemdoUsuario");
     
        lista.Add(fr);
    }
    conexao.Close();
    return lista;
}    

 public faleconosco buscarporID (int IdUsuario)
 {
    MySqlConnection Conexao = new MySqlConnection(DadosdeConexao);
    Conexao.Open();
    String Query = "SELECT * FROM entreemcontato WHERE  IdUsuario = @IdUsuario";
    MySqlCommand Comando = new MySqlCommand(Query, Conexao);
    Comando.Parameters.AddWithValue("@IdUsuario",IdUsuario);
    MySqlDataReader reader = Comando.ExecuteReader();
    faleconosco fr = new faleconosco();
    while (reader.Read())
    {
        
     fr.IdUsuario = reader.GetInt32("IdUsuario");
       
        if(!reader.IsDBNull(reader.GetOrdinal("nomeUsuario")))
            fr.nomeUsuario = reader.GetString("nomeUsuario");
       
        if(!reader.IsDBNull(reader.GetOrdinal("emailUsuario")))
            fr.emailUsuario = reader.GetString("emailUsuario");

        if(!reader.IsDBNull(reader.GetOrdinal("TelefoneUsuario")))
            fr.TelefoneUsuario = reader.GetString("TelefoneUsuario");

        if(!reader.IsDBNull(reader.GetOrdinal("mensagemdoUsuario")))
            fr.mensagemdoUsuario = reader.GetString("mensagemdoUsuario");
     
    }
    Conexao.Close();
    return fr;
 }

 public void deletar(int IdUsuario)
 {
    MySqlConnection Conexao = new MySqlConnection(DadosdeConexao);
    Conexao.Open();
    String Query = "DELETE FROM entreemcontato Where IdUsuario = @IdUsuario";
    MySqlCommand Comando = new MySqlCommand(Query, Conexao);
    Comando.Parameters.AddWithValue("@IdUsuario", IdUsuario);
    Comando.ExecuteNonQuery();
    Conexao.Close();
 }

  public void editar(faleconosco f)
  {
        MySqlConnection Conexao = new MySqlConnection(DadosdeConexao);
        Conexao.Open();
        string Query = "UPDATE entreemcontato SET nomeUsuario = @nomeUsuario, emailUsuario = @emailUsuario, loginUsuario = @loginUsuario, senhaUsuario = @senhaUsuario, datadenascimentoUsuario = @datadenascimentoUsuario, sexodoUsuario = @sexodoUsuario, mensagemdoUsuario = @mensagemdoUsuario WHERE IdUsuario=@IdUsuario";
        MySqlCommand Comando = new MySqlCommand(Query, Conexao);

        Comando.Parameters.AddWithValue("@nomeUsuario", f.nomeUsuario);
        Comando.Parameters.AddWithValue("@emailUsuario", f.emailUsuario);
        Comando.Parameters.AddWithValue("@TelefoneUsuario", f.TelefoneUsuario);
        Comando.Parameters.AddWithValue("@mensagemdoUsuario", f.mensagemdoUsuario);
        Comando.ExecuteNonQuery();
        Conexao.Close();

  }

}


}
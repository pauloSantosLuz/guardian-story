using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Data;
using Mono.Data.SqliteClient;

public class ConexaoBanco:MonoBehaviour{
	string urlDataBase = "URI=file:MasterSQLite.db";
	
	public GameObject dificuldadeText;
	public GameObject pontuacaoText;
	public GameObject tempoText;

	public GameObject panelResultado;

	private Transform posicaoDificuldade;
	private Transform posicaoPontuacao;
	private Transform posicaoTempo;




	public void CriaTabela()
	{
		IDbConnection connection = new SqliteConnection(urlDataBase);
		IDbCommand command = connection.CreateCommand();
		connection.Open();

		string sql = "CREATE TABLE IF NOT EXISTS highscore (id INT PRIMARY KEY,dificuldade VARCHAR(20), pontuacao INT, timer VARCHAR(10))";
		//string sql = "DROP TABLE IF EXISTS highscore";
		command.CommandText = sql;
		command.ExecuteNonQuery();	

		connection.Close();

		Debug.Log("Tabela criada");
	}

	public void SalvarJogo(string dificuldade, string pontuacao, string tempo)

	{
		IDbConnection connection = new SqliteConnection(urlDataBase);
		IDbCommand command = connection.CreateCommand();
		connection.Open();

		string sql = "INSERT INTO highscore (dificuldade, pontuacao, timer) "
		+"VALUES ('"+ dificuldade + "', '"+ pontuacao + "', '"+ tempo + "')";
		command.CommandText = sql;
		command.ExecuteNonQuery();

		connection.Close();
		Debug.Log("JogoSalvo");
	}	
	public void ListaRecordes()
	{
		IDbConnection connection = new SqliteConnection(urlDataBase);
		IDbCommand command = connection.CreateCommand();
		connection.Open();

		string sql = "SELECT dificuldade, pontuacao, timer " + "FROM highscore ORDER BY pontuacao ASC LIMIT 4";
		command.CommandText = sql;
		IDataReader reader = command.ExecuteReader();

		this.posicaoDificuldade  = dificuldadeText.transform;		
		this.posicaoPontuacao  = pontuacaoText.transform;		
		this.posicaoTempo  = tempoText.transform;
		float deltaY = 60f;		
		while (reader.Read())
		{
			if(this.dificuldadeText.GetComponent<TMPro.TextMeshProUGUI>().text.Equals("0"))
				this.dificuldadeText.GetComponent<TMPro.TextMeshProUGUI>().text = reader.GetString(0);
			else{
				var instancia = Instantiate(this.dificuldadeText,posicaoDificuldade.position - new Vector3(0f,deltaY,0f),this.dificuldadeText.transform.rotation,this.panelResultado.transform);
				instancia.transform.localScale = this.dificuldadeText.transform.localScale;
				this.posicaoDificuldade = instancia.transform;
				this.dificuldadeText.GetComponent<TMPro.TextMeshProUGUI>().text = reader.GetString(0);

			}

			if(pontuacaoText.GetComponent<TMPro.TextMeshProUGUI>().text.Equals("0"))
				pontuacaoText.GetComponent<TMPro.TextMeshProUGUI>().text = reader.GetString(1);
			else{
				var instancia = Instantiate(this.pontuacaoText,posicaoPontuacao.position - new Vector3(0f,deltaY,0f),this.pontuacaoText.transform.rotation,this.panelResultado.transform);
				instancia.transform.localScale = this.pontuacaoText.transform.localScale;
				this.posicaoPontuacao = instancia.transform;
				this.pontuacaoText.GetComponent<TMPro.TextMeshProUGUI>().text = reader.GetInt32(1).ToString();

			}

			if(tempoText.GetComponent<TMPro.TextMeshProUGUI>().text.Equals("0"))
				tempoText.GetComponent<TMPro.TextMeshProUGUI>().text = reader.GetString(2);
			else{
				var instancia = Instantiate(this.tempoText,posicaoTempo.position - new Vector3(0f,deltaY,0f),this.tempoText.transform.rotation,this.panelResultado.transform);
				instancia.transform.localScale = this.tempoText.transform.localScale;
				this.posicaoTempo = instancia.transform;
				this.tempoText.GetComponent<TMPro.TextMeshProUGUI>().text = reader.GetString(2);

			}
		}
		connection.Close();

	}	
}

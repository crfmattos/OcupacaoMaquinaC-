using System;
using System.Globalization;

List<AlocacaoHoras> bancoDeHoras = new();
List<Maquina> equipamentos = new();
List<Projeto> projetos =new();


List<Maquina> CriarListaEquipamentos()
    {
        List<Maquina> LISTADEQUIPAMENTOS = new()
            {
                new Maquina("Mufla", 100, 100000),
                new Maquina("PHMETRO", 100, 800000),
                new Maquina("Balança Analítica" , 100, 500000)
            };
        return LISTADEQUIPAMENTOS;
    }
List<Projeto> CriarListaProjetos()
    {
         List<Projeto> LISTAINFORMACOESPROJETOS = new()
{
    new Projeto("Projeto_12345", "2023-03-01", "2024-03-01", "Leon"),
    new Projeto("Projeto_54321", "2022-03-01", "2024-03-01", "Joao"),
    new Projeto("Projeto_35241", "2023-03-01", "2024-01-01", "Henrique")
};
        return LISTAINFORMACOESPROJETOS;
    }
List<AlocacaoHoras> CriarListaAlocacoes()
    {
        List<AlocacaoHoras> LISTADEHORAS = new()
{
    new AlocacaoHoras(55, equipamentos[0], projetos[0]),
    new AlocacaoHoras(22, equipamentos[0], projetos[1]),
    new AlocacaoHoras(32, equipamentos[1], projetos[1]),
    new AlocacaoHoras(10, equipamentos[2], projetos[2])
};
        return LISTADEHORAS;
    }
 

void PopularBancoDeMaquinas()
{
    equipamentos.AddRange(CriarListaEquipamentos());
}

void CriarNovaMaquina(string nome, int hora, int valor)
{
 equipamentos.Add(new Maquina(nome, hora, valor));
}

void PopularBancoDeProjetos()
{
    projetos.AddRange(CriarListaProjetos());
}

void CriarNovoProjeto(string id, string dataInicio, string dataConclusao, string lider)
{
    projetos.Add(new Projeto(id, dataInicio, dataConclusao, lider));
}



void PopularBancoDeHoras()
{
    bancoDeHoras.AddRange(CriarListaAlocacoes());
}

void CriarNovaAlocacao(int qtdHora, Maquina maquina, Projeto projeto)
{
    bancoDeHoras.Add(new AlocacaoHoras(qtdHora, maquina, projeto));
}

int CalcularHoraMaquina(Maquina maquina)
{
    int somaHora = bancoDeHoras.Where(m => m.maquina == maquina).Sum(hora => hora.qtdHoraPorMaquina);
    return somaHora;
}

List<AlocacaoHoras> FiltrarHorasPorMaquina(Maquina maquina)
{
    List<AlocacaoHoras> HorasFiltradas = bancoDeHoras.Where((horaPercorrida) => horaPercorrida.maquina == maquina).ToList();
    return HorasFiltradas; 
}



List<double> ListarPorcentagensFiltradas(List<AlocacaoHoras> horasFiltradas)
{
    List<double> porcentagens = new();
    foreach(var hora in horasFiltradas)
    {
        porcentagens.Add(hora.qtdHoraPorMaquina / hora.maquina.limiteHoras); 
    }
    return porcentagens;
}

int SomarHorasDeTodasMaquinas()
{
    int horasTotais =  bancoDeHoras.Sum(b => b.qtdHoraPorMaquina);
    return horasTotais;
}

double CalcularOcupacaoMaquina(Maquina maquina)
{
    double ocupacaoMaquina = FiltrarHorasPorMaquina(maquina).Sum(x => x.qtdHoraPorMaquina) / maquina.limiteHoras;
    return ocupacaoMaquina * 100;

}

List<AlocacaoHoras> FiltrarPorProjeto(Projeto projeto)
{
    List<AlocacaoHoras> projetosFiltrados = bancoDeHoras.Where((projetoPercorrido) => projetoPercorrido.projeto == projeto).ToList();
    return projetosFiltrados;
}

double calcularValorHorasAlocadas(Maquina maquina)
{
    List<AlocacaoHoras> alocacoesDaMaquina = FiltrarHorasPorMaquina(maquina);
    int horasAlocadas = CalcularHoraMaquina(maquina);
    double valorHora = maquina.calcularValorHora();
    return horasAlocadas * valorHora;
}

DateTime CalcularQtdDeMeses(DateTime data, int numeroDeMeses)
{
        

        DateTime dataAtual = DateTime.Now;
        DateTime dataSubtraida = data.AddMonths(-numeroDeMeses);
        return dataSubtraida;
}


void ExibirEquipamentos()
{
    foreach( var equipamento in equipamentos)
    {
        Console.WriteLine(equipamento.nome);
    }
}

//MostrarOcuya




// -=-=-=-=-=-=-=-=-=-=--==-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-==-=-=-=-==-=-=-

PopularBancoDeMaquinas();

PopularBancoDeProjetos();

PopularBancoDeHoras();

Console.WriteLine(CalcularHoraMaquina(equipamentos[0]));

CriarNovaMaquina("Ar-Condicionado", 5, 10000);

ExibirEquipamentos();

Console.WriteLine(CalcularOcupacaoMaquina(equipamentos[0]));

var x = FiltrarHorasPorMaquina(equipamentos[0]);
var y = ListarPorcentagensFiltradas(x);
foreach (var numero in y) {
    Console.WriteLine($"{numero*100}%");
}


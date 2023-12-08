# Digix Challenge

> Esté é um projeto criado para o desafio da empresa Digix utilizando C#.Net.

## Estrutura da solução

### Clean Architecture

Criei o projeto pensando na Clean Arc. e os padrões e benefícios que a mesma traz. Porém, conforme a estrutura foi evoluindo, me dei conta de que as regras de validação são mais de aplicação do que de domínio em si. Sendo assim, você encontrará no projeto que criei:

#### UnitTests - Digix.CasaPopular.SelecaoDeFamilia.Application
Aqui está o coração da minha proposta de solução. Para evitar um emaranhado de if/elseif/else para as regras de pontuação da família, me baseei em um padrão de design chamado [Rules Design Pattern](https://medium.com/swlh/rules-pattern-1c59854547b).
Basicamente o que este padrão faz é criar uma interface para definir a estrutura de uma regra onde:
- Se uma entidade atender à regra especificada
- Aplicamos as devidas ações sobre a entidade

Sendo assim vocês podem observar melhor os arquivos:
- SeedWork/IRule.cs - Interface que define a estrutura de regra genérica
- UseCase/Family/FamilySelection/Rules/*
- --- IFamilySelectionRule.cs - Interface que implementa IRule definindo uma interface voltada para critérios de seleção de famílias
- --- Os remais arquivos são as implementações das regras efetivamente

##### Como a aplicação das regras funciona?
O calculo de pontuação hoje é feito dentro do UseCase CalculateScore. 
É aqui que, através de reflection, eu pego todas as regras que implementam a interface IFamilySelectionRule e aplico sobre o dto que representa uma família, ou seja, para incluir uma nova regra basta implementar a interface IFamilySelectionRule que será automaticamente incluida no cálculo.

#### UnitTests - Digix.CasaPopular.SelecaoDeFamilia.UnitTest
Criei algumas camadas de teste unitário para garantir:
- A funcionalidade unitária de cada regra de forma isolada
- A seleção de familia em seus diversos cenários
- A validação das entidades do domínio*
  
#### UnitTests - Digix.CasaPopular.SelecaoDeFamilia.Domain*
Uma estrutura simples de domínio, contemplando as entidades Pessoa e Família.

#### UnitTests - Digix.CasaPopular.SelecaoDeFamilia.ConsoleConsumer*
Um simples applicativo para testar as chamadas do use case que realiza efetivamente a seleção.

OBS: Os itens marcados com * são trabalhos que, depois que comecei a construir, avaliei que possivelmente eles nem eram necessários para este momento.

## Componentes
- [Bogus](https://github.com/bchavez/Bogus) - Utilizada para gerar dados randômicos de testes


## 🤝 Colaboradores

<table>
  <tr>
    <td align="center">
      <a href="#" title="Daniel Lourenço Curado">
        <img src="https://avatars.githubusercontent.com/u/649317?s=400&v=4" width="100px;" alt="Foto do Daniel Lourenço Curado no GitHub"/><br>
        <sub>
          <b>Daniel Lourenço Curado</b>
        </sub>
      </a>
    </td>
  </tr>
</table>

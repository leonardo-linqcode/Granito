
# Cálculo de juros compostos

Projeto de avaliação técnica para vaga de Desenvolvedor Back-end na Granito.



## Documentação da API de Cálculo
https://granito-calculo-api.azurewebsites.net

[![Build Status](https://dev.azure.com/linqcode/Schedule%20App/_apis/build/status/leonardo-linqcode.Granito.Calculo?branchName=master)](https://dev.azure.com/linqcode/Schedule%20App/_build/latest?definitionId=3&branchName=master)

#### Retorna valor com juros aplicado

```http
  GET api/calculajuros?valorinicial=&meses=
```

| Parâmetro   | Tipo       | Descrição                           |
| :---------- | :--------- | :---------------------------------- |
| `valorinicial` | `decimal` | **Obrigatório**. Valor base para cálculo. |
| `meses` | `int` | **Obrigatório**. Quantidade de meses para cálculo de juros. |

#### Retorna o link do projeto no GitHub

```http
  GET api/showmethecode
```

## Documentação da API de Taxas
https://granito-taxas-api.azurewebsites.net

[![Build Status](https://dev.azure.com/linqcode/Schedule%20App/_apis/build/status/leonardo-linqcode.Granito.Taxas?branchName=master)](https://dev.azure.com/linqcode/Schedule%20App/_build/latest?definitionId=2&branchName=master)

#### Retorna a taxa atual de juros

```http
  GET /api/taxas
```
## Variáveis de Ambiente

Para rodar o projeto `Granito.Calculo.Api`, você vai precisar adicionar as seguintes variáveis de ambiente

`TaxasApiUrl`= https://granito-taxas-api.azurewebsites.net/ ou https://localhost


## Stack utilizada

**Back-end:** .Net 7.0, c#, xUnit, FluentValidation, MediatR, Docker, CQRS Pattern
## Autores

- [@leonardosilva](https://www.github.com/leonardo-linqcode)


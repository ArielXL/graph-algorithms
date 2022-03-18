#include<bits/stdc++.h>
#define endl '\n'

using namespace std;

int casos, escaleras, serpientes, a, b;
vector<int> grafo[105];
bool visitados[105];
bool escaleras_serpientes[105];
int distancia[105];
int resp = 0;

void BFS(int inicio)
{
    queue<int> cola;

    cola.push(inicio);
    visitados[inicio] = true;

    while(!cola.empty())
    {
        int elemento = cola.front();
        cola.pop();

        for(int i = 0; i < grafo[elemento].size(); i++)
        {
            int temp = grafo[elemento][i];

            if(!visitados[temp])
            {
                visitados[temp] = true;
                cola.push(temp);

                if(escaleras_serpientes[temp])
                    distancia[temp] = distancia[elemento];
                else
                    distancia[temp] = distancia[elemento] + 1;

                if(temp == 100)
                    return;
            }
        }
    }
}

void construye_grafo()
{
    for(int i = 1; i <= 100; i++)
    {
        if(grafo[i].size() == 0)
        {
            for(int j = 1; j <= 6; j++)
            {
                if(i + j > 100)
                    break;
                else
                    grafo[i].push_back(i + j);
            }
        }
    }
}

void limpiar()
{
    resp = 0;
    for(int i = 0; i < 104; i++)
    {
        visitados[i] = false;
        distancia[i] = 0;
        grafo[i].clear();
    }
}

void imprimir()
{
    cout << "El array visitados es:" << endl;
    for(int i = 1; i <= 100; i++)
    {
        cout << visitados[i] << " ";
    }
    cout << endl;

    cout << "El array distancia es:" << endl;
    for(int i = 1; i <= 100; i++)
    {
        cout << distancia[i] << " ";
    }
    cout << endl;
}

int main()
{
    ios_base :: sync_with_stdio(0);
    cin.tie(0);

    cin >> casos;

    while(casos--)
    {
        limpiar();

        cin >> escaleras;
        for(int i = 0; i < escaleras; i++)
        {
            cin >> a >> b;
            grafo[a].push_back(b);
            escaleras_serpientes[a] = true;
        }

        cin >> serpientes;
        for(int i = 0; i < serpientes; i++)
        {
            cin >> a >> b;
            grafo[a].push_back(b);
            escaleras_serpientes[a] = true;
        }

        construye_grafo();
        BFS(1);
        resp = distancia[100];

        cout << resp << endl;
    }
}

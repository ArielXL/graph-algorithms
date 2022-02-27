#include <bits/stdc++.h>
#define endl '\n'

using namespace std;
typedef pair<int, int> pii;

int vertices, aristas, u, v, w;
vector<pii> grafo[10005];
int d[10005];
int pi[10005];
bool marcados[10005];
vector<int> ciclo;

void inicializar(int inicio)
{
    for(int i = 0; i < vertices; i++)
    {
        d[i] = INT_MAX;
        pi[i] = -1;
        marcados[i] = false;
    }
    d[inicio] = 0;
}

bool relax(int u, int v, int w)
{
    if(d[v] > d[u] + w)
    {
        d[v] = d[u] + w;
        pi[v] = u;
        return true;
    }
    else
        return false;
}

void dame_ciclo(int i, int j)
{
    if(i == j)
    {
        ciclo.push_back(i);
        return;
    }
    else
    {
        dame_ciclo(pi[i], j);
        ciclo.push_back(i);
    }
}

void busca_ciclo(int i)
{
    while(!marcados[i])
    {
        marcados[i] = true;
        i = pi[i];
    }
    dame_ciclo(pi[i], i);
}

bool BellmanFord(int inicio)
{
    inicializar(inicio);

    for(int i = 0; i < vertices - 1; i++)
    {
        for(int j = 0; j < vertices; j++)
        {
            for(int k = 0; k < grafo[j].size(); k++)
            {
                relax(j, grafo[j][k].first, grafo[j][k].second);
            }
        }
    }

    for(int i = 0; i < vertices; i++)
    {
        for(int j = 0; j < grafo[i].size(); j++)
        {
            if(d[grafo[i][j].first] > d[i] + grafo[i][j].second)
            {
                busca_ciclo(i);
                return false;
            }
        }
    }

    return true;
}

int main()
{
    cin >> vertices >> aristas;

    for(int i = 0; i < aristas; i++)
    {
        cin >> u >> v >> w;
        u--; v--;
        grafo[u].push_back(make_pair(v, w));
    }

    if(!BellmanFord(0))
    {
        cout << "SI" << endl;
        cout << ciclo.size() << endl;

        for(int i = 0; i < ciclo.size(); i++)
        {
            cout << ciclo[i] + 1 << " ";
        }
        cout << endl;
    }
    else
        cout << "NO" << endl;
}

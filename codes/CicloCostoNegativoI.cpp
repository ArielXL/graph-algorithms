#include <bits/stdc++.h>
#define endl '\n'

using namespace std;
typedef pair<int, int> pii;

int vertices, aristas, u, v, w;
vector<pii> grafo[10005];
int d[10005];

void inicializar(int inicio)
{
    for(int i = 0; i < vertices; i++)
    {
        d[i] = INT_MAX;
    }
    d[inicio] = 0;
}

bool relax(int u, int v, int w)
{
    if(d[v] > d[u] + w)
    {
        d[v] = d[u] + w;
        return true;
    }
    else
        return false;
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
                return false;
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
        cout << "SI" << endl;
    else
        cout << "NO" << endl;
}

#include<bits/stdc++.h>
#define endl '\n'

using namespace std;

typedef pair<int, int> pii;

int vertices, aristas, a, b;
vector<int> grafo[10005];
int tiempo;
int d[10005];
int low[10005];
int pi[10005];
bool marcados[10005];
vector<pii> aristas_puentes;

void DFS_Visit(int elemento)
{
    marcados[elemento] = true;
    tiempo++;
    d[elemento] = tiempo;
    low[elemento] = d[elemento];

    for(int i = 0; i < grafo[elemento].size(); i++)
    {
        int temp = grafo[elemento][i];

        if(!marcados[temp])
        {
            pi[temp] = elemento;
            DFS_Visit(temp);
            low[elemento] = min(low[elemento], low[temp]);
        }
        else if(pi[elemento] != temp)
            low[elemento] = min(low[elemento], d[temp]);
    }
    if(pi[elemento] != INT_MIN && low[elemento] ==d[elemento])
        aristas_puentes.push_back(make_pair(pi[elemento], elemento));
}

void DFS()
{
    for(int i = 1; i <= vertices; i++)
    {
        if(!marcados[i])
            DFS_Visit(i);
    }
}

void dame_aristas_puentes()
{
    tiempo = 0;
    pi[1] = INT_MIN;
    DFS();
}

int main()
{
	ios_base :: sync_with_stdio(0);
	cin.tie(0);

    cin >> vertices >> aristas;

    for(int i = 0; i < aristas; i++)
    {
        cin >> a >> b;

        grafo[a].push_back(b);
        grafo[b].push_back(a);
    }

    dame_aristas_puentes();

    if(aristas_puentes.size() == 0)
        cout << "-1" << endl;
    else
    {
        cout << aristas_puentes.size() << endl;

        for(int i = 0; i < aristas_puentes.size(); i++)
        {
            pii par = aristas_puentes[i];
            cout << par.first << " " << par.second << endl;
        }
    }
}

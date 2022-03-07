#include<bits/stdc++.h>

using namespace std;

#define endl '\n'

int vertices, aristas, a, b, u, w;
vector<int> grafo[10005];

vector<int> resp;
int pi[10005];
bool visitados[10005];
bool ya = false;

void BuscarCamino(int q)
{
    if(pi[q] == 0)
    {
        resp.push_back(q);
        return;
    }
    else
    {
        resp.push_back(q);
        BuscarCamino(pi[q]);
    }
}

void DFS_Visit(int elemento)
{
    visitados[elemento] = true;

    for(int i = 0; i < grafo[elemento].size(); i++)
    {
        int q = grafo[elemento][i];
        if(!visitados[q])
        {
            pi[q] = elemento;
            if(q == w)
            {
                BuscarCamino(q);
                reverse(resp.begin(), resp.end());
                ya = true;
                break;
            }

            DFS_Visit(q);
            if(ya)
                break;
        }
    }
}

void EncontrandoCamino_DFS()
{
    for(int i = 1; i < 10005; i++)
    {
        pi[i] = INT_MIN;
        if(i == u)
            pi[i] = 0;
    }

    DFS_Visit(u);

    if(ya)
    {
        cout << resp.size() << endl;
        for(int i = 0; i < resp.size(); i++)
        {
            cout << resp[i] << " ";
        }
        cout << endl;
    }
    else
        cout << -1 << endl;
}

int main()
{
	ios_base :: sync_with_stdio(0);
	cin.tie(0);

    cin >> vertices >> aristas;
    cin >> u >> w;

    for(int i = 1; i < aristas; i++)
    {
        cin >> a >> b;
        grafo[a].push_back(b);
    }

    EncontrandoCamino_DFS();
}


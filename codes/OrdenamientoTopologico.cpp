#include<bits/stdc++.h>
#define endl '\n'

using namespace std;

int vertices, aristas, a, b;
vector<int> grafo[10005];
int indegree[10005];
int resp[10005];

bool orden_topologico()
{
    int cont = 0;
    for(int i = 1; i <= vertices; i++)
    {
        if (indegree[i] == 0)
        {
            resp[cont] = i;
            cont++;
            indegree[i]--;
            for (int j = 0; j < grafo[i].size(); j++)
            {
                indegree[grafo[i][j]]--;
            }
            i = 0;
        }
    }

    if (cont == vertices)
        return true;
    else
        return false;
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
        indegree[b] += 1;
    }

    if(orden_topologico())
    {
        cout << "True" << endl;
        for(int i = 0; i < vertices; i++)
        {
            cout << resp[i] << " ";
        }
        cout << endl;
    }
    else
        cout << "False" << endl;
}

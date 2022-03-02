#include<bits/stdc++.h>
#define endl '\n'

using namespace std;

typedef pair<long long, int> pli;

int vertices, aristas, casos, origen;
long long costo;
vector<pli> grafo[200005];
long long d[200005];
int pi[200005];
set<pli> avl;

void inicializar()
{
    for(int i = 0; i <= vertices; i++)
    {
        d[i] = INT_MAX;
        pi[i] = INT_MAX;
    }

    d[origen] = 0;
    pi[origen] = -1;
}

bool relax(int a, int b, long long w)
{
    if(d[b] > d[a] + w)
    {
        d[b] = d[a] + w;
        pi[b] = a;
        return true;
    }
    else
        return false;
}

void dijkstra()
{
    inicializar();

    avl.insert(make_pair(0, origen));

    while(!avl.empty())
    {
        pli elemento = *avl.begin();
        avl.erase(avl.begin());

        for(int i = 0; i < grafo[elemento.second].size(); i++)
        {
            pli temp = grafo[elemento.second][i];

            if(relax(elemento.second, temp.second, temp.first))
            {
                set<pli>:: iterator iterador = avl.find(make_pair(d[temp.second], temp.second));
                if(iterador != avl.end())
                    avl.erase(iterador);

                avl.insert(make_pair(d[temp.second], temp.second));
            }
        }
    }
}

int main()
{
    ios_base :: sync_with_stdio(0);
    cin.tie(0);

    cin >> casos;

    while(casos--)
    {
        cin >> vertices >> aristas;

        for(int i = 0; i < aristas; i++)
        {
            int a, b;
            cin >> a >> b >> costo;

            grafo[a].push_back(make_pair(costo, b));
            grafo[b].push_back(make_pair(costo, a));
        }

        cin >> origen;
        dijkstra();

        for(int i = 1; i <= vertices; i++)
        {
            if(i != origen)
            {
                if(d[i] == INT_MAX)
                    cout << -1 << " ";
                else
                    cout << d[i] << " ";
            }
        }
        cout << endl;
    }
}

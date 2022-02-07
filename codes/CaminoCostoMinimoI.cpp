#include<bits/stdc++.h>
#define endl '\n'

using namespace std;
typedef pair<int, int> pii;

int vertices, aristas, u, v;
int costo;
vector<pii> grafo[200001];
int d[200001];
int pi[200001];
bool marcados[200001];
priority_queue<pii> heap;
vector<int> camino;

inline void inicializar(int origen)
{
    for(int i = 0; i <= vertices; i++)
    {
        d[i] = INT_MAX;
        pi[i] = INT_MAX;
        marcados[i] = false;
    }

    d[origen] = 0;
    pi[origen] = -1;
}

inline bool relax(int a, int b, int w)
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

void Dijkstra(int origen)
{
    inicializar(origen);
    heap.push({0, origen});
    pii curr; int next;

    while(!heap.empty())
    {
    	curr = heap.top();
    	heap.pop();

    	if(marcados[curr.second])
            continue;
        marcados[curr.second] = true;

    	for(auto edge : grafo[curr.second])
        {
            next = edge.second;
    		costo = edge.first;

    		if(!marcados[next] && relax(curr.second, next, costo))
                heap.push({-d[next], next});
        }
    }
}

inline void dame_camino(int inicio, int final)
{
    if(inicio == final)
    {
        camino.push_back(inicio);
        return;
    }
    else
    {
        camino.push_back(final);
        dame_camino(inicio, pi[final]);
    }
}

int main()
{
    ios_base :: sync_with_stdio(0);
    cin.tie(0);

    cin >> vertices >> aristas >> u >> v;

    for(int i = 0; i < aristas; i++)
    {
        int a, b;
        cin >> a >> b >> costo;

        grafo[a].push_back(make_pair(costo, b));
        grafo[b].push_back(make_pair(costo, a));
    }

    Dijkstra(u);
    dame_camino(u, v);
	reverse(camino.begin(), camino.end());

    cout << camino.size() << endl;
    for(int i = 0;i < camino.size();++i)
    {
        if(i == camino.size() - 1)
            cout << camino[i] << endl;
        else
            cout << camino[i] << " ";
	}
}

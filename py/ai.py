def readmtk(path):
    matrix = []
    with open(path, 'r') as f:
        lines = f.readlines()
        for line in lines:
            matrix.append([int(i) for i in line.strip().split(' ')])
    return matrix

def readh(path):
    with open(path, 'r') as f:
        line = f.readline()
        h = [int(i) for i in line.strip().split(' ')]
    return h

def printPath(parent, stop):
    path = []
    tmp = stop
    while tmp != -1:
        path.append(tmp)
        tmp = parent[tmp]
    path.reverse()
    for i in range(len(path)):
        if i == len(path) - 1:
            print(path[i], end='')
        else:
            print(path[i], end=' -> ')

def BFS(matrix, start, stop):
    Close = []
    Open = [start]
    parent = [-1] * len(matrix)
    while Open:
        cur_node = Open.pop(0)
        if cur_node == stop:
            printPath(parent, stop)
            return
        Close.append(cur_node)
        Tn = []
        for next_node in range(len(matrix)):
            if matrix[cur_node][next_node] > 0 and next_node not in Open and next_node not in Close:
                Tn.append(next_node)
                parent[next_node] = cur_node
        Open = Open + Tn
    print("dell co duong di")

def DFS(matrix, start, stop):
    Close = []
    Open = [start]
    parent = [-1] * len(matrix)
    while Open:
        cur_node = Open.pop(0)
        if cur_node == stop:
            printPath(parent, stop)
            return
        Close.append(cur_node)
        Tn = []
        for next_node in range(len(matrix)):
            if matrix[cur_node][next_node] > 0 and next_node not in Open and next_node not in Close:
                Tn.append(next_node)
                parent[next_node] = cur_node
        Open = Tn + Open
    print("dell co duong di")

def hillClimbing(matrix, h, start, stop):
    Close = []
    Open = [start]
    parent = [-1] * len(matrix)
    while Open:
        cur_node = Open.pop(0)
        if cur_node == stop:
            printPath(parent, stop)
            return
        Close.append(cur_node)
        Tn = []
        for next_node in range(len(matrix)):
            if matrix[cur_node][next_node] > 0 and next_node not in Open and next_node not in Close:
                Tn.append(next_node)
                parent[next_node] = cur_node
        Tn.sort(key=lambda x: h[x])
        Open = Tn + Open
    print("dell co duong di")

def bestFS(matrix, h, start, stop):
    Close = []
    Open = [start]
    parent = [-1] * len(matrix)
    while Open:
        cur_node = Open.pop(0)
        if cur_node == stop:
            printPath(parent, stop)
            return
        Close.append(cur_node)
        Tn = []
        for next_node in range(len(matrix)):
            if matrix[cur_node][next_node] > 0 and next_node not in Open and next_node not in Close:
                Tn.append(next_node)
                parent[next_node] = cur_node
        Open = Tn + Open
        Open.sort(key=lambda x: h[x])
    print("dell co duong di")

def AT(matrix, h, start, stop):
    Close = []
    Open = [start]
    parent = [-1] * len(matrix)
    g = [0] * len(matrix)
    g[start] = h[start]
    while Open:
        cur_node = Open.pop(0)
        if cur_node == stop:
            printPath(parent, stop)
            return
        Close.append(cur_node)
        Tn = []
        for next_node in range(len(matrix)):
            if matrix[cur_node][next_node] > 0 and next_node not in Open and next_node not in Close:
                g[next_node] = g[cur_node] + h[next_node]
                parent[next_node] = cur_node
                Tn.append(next_node)
        Open = Tn + Open
        Open.sort(key=lambda x: g[x])
    print("dell co duong di")

def CMS(matrix, h, start, stop):
    Close = []
    Open = [start]
    parent = [-1] * len(matrix)
    g = [0] * len(matrix)
    g[start] = h[start]
    while Open:
        cur_node = Open.pop(0)
        if cur_node == stop:
            printPath(parent, stop)
            return
        Close.append(cur_node)
        Tn = []
        for next_node in range(len(matrix)):
            if matrix[cur_node][next_node] > 0 and next_node not in Open and next_node not in Close:
                g[next_node] = g[cur_node] + h[next_node]
                parent[next_node] = cur_node
                Tn.append(next_node)
            elif matrix[cur_node][next_node] > 0 and next_node in Open:
                g_new = g[cur_node] + h[next_node]
                if g_new < g[next_node]:
                    g[next_node] = g_new
                    parent[next_node] = cur_node
        Open = Tn + Open
        Open.sort(key=lambda x: g[x])
    print("Dell co duong di")

def Astar(matrix, h, start, stop):
    Close = []
    Open = [start]
    parent = [-1] * len(matrix)
    g = [0] * len(matrix)
    g[start] = 0
    f = [0] * len(matrix)
    f[start] = g[start] + h[start]
    while Open:
        cur_node = Open.pop(0)
        if cur_node == stop:
            printPath(parent, stop)
            return
        Close.append(cur_node)
        Tn = []
        for next_node in range(len(matrix)):
            if matrix[cur_node][next_node] > 0 and next_node not in Open and next_node not in Close:
                g[next_node] = g[cur_node] + matrix[cur_node][next_node]
                f[next_node]  = g[next_node] + h[next_node]
                parent[next_node] = cur_node
                Tn.append(next_node)
            elif matrix[cur_node][next_node] > 0 and (next_node in Open or next_node in Close):
                g_new = g[cur_node] + matrix[cur_node][next_node]
                f_new = g_new + h[next_node]
                if f_new < f[next_node]:
                    g[next_node] = g_new
                    f[next_node] = f_new
                    parent[next_node] = cur_node
        Open = Tn + Open
        Open.sort(key=lambda x: f[x])
    print("Dell co duong di")

if __name__ == "__main__":
    matrix = readmtk('input.mtk')
    h = readh('input.h')
    CMS(matrix, h, 0, 7)
    print()
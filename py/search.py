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
    g = [float('inf')] * len(matrix)
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
    g = [float('inf')] * len(matrix)
    g[start] = h[start]
    while Open:
        cur_node = Open.pop(0)
        if cur_node == stop:
            printPath(parent, stop)
            return
        Close.append(cur_node)
        Tn = []
        for next_node in range(len(matrix)):
            if matrix[cur_node][next_node] > 0:
                if next_node not in Open and next_node not in Close:
                    g[next_node] = g[cur_node] + h[next_node]
                    parent[next_node] = cur_node
                    Tn.append(next_node)
                elif next_node in Open:
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
    g = [float('inf')] * len(matrix)
    g[start] = 0
    f = [float('inf')] * len(matrix)
    f[start] = g[start] + h[start]
    while Open:
        cur_node = Open.pop(0)
        if cur_node == stop:
            printPath(parent, stop)
            return
        Close.append(cur_node)
        Tn = []
        for next_node in range(len(matrix)):
            if matrix[cur_node][next_node] > 0:
                if next_node not in Open and next_node not in Close:
                    g[next_node] = g[cur_node] + matrix[cur_node][next_node]
                    f[next_node]  = g[next_node] + h[next_node]
                    parent[next_node] = cur_node
                    Tn.append(next_node)
                elif next_node in Open or next_node in Close:
                    g_new = g[cur_node] + matrix[cur_node][next_node]
                    f_new = g_new + h[next_node]
                    if f_new < f[next_node]:
                        g[next_node] = g_new
                        f[next_node] = f_new
                        parent[next_node] = cur_node
        Open = Tn + Open
        Open.sort(key=lambda x: f[x])
    print("Dell co duong di")

def Branch_and_Bound(matrix, h, start, stop):
    Close = []
    Open = [start]
    parent = [-1] * len(matrix)
    g = [float('inf')] * len(matrix)
    g[start] = 0
    f = [float('inf')] * len(matrix)
    f[start] = g[start] + h[start]
    min = float('inf')
    found = False
    while Open:
        cur_node = Open.pop(0)
        Close.append(cur_node)
        if cur_node == stop:
            found = True
            if f[cur_node] < min:
                min = f[cur_node]
        elif f[cur_node] > min:
            continue
        elif f[cur_node] < min:
            Tn = []
            for next_node in range(len(matrix)):
                if matrix[cur_node][next_node] > 0:
                    # KHONG thuoc Open, KHONG thuoc Close
                    if next_node not in Open and next_node not in Close:
                        g[next_node] = g[cur_node] + matrix[cur_node][next_node]
                        f[next_node] = g[next_node] + h[next_node]
                        parent[next_node] = cur_node
                        Tn.append(next_node)
                    # KHONG thuoc Open, thuoc Close
                    elif next_node not in Open and next_node in Close:
                        g_new = g[cur_node] + matrix[cur_node][next_node]
                        f_new = g_new + h[next_node]
                        if f_new < f[next_node]:
                            g[next_node] = g_new
                            f[next_node] = f_new
                            parent[next_node] = cur_node
                            Tn.append(next_node)
                    # (thuoc Open, KHONG thuoc Close) hoac (thuoc Open, thuoc Close)
                    elif next_node in Open:
                        g_new = g[cur_node] + matrix[cur_node][next_node]
                        f_new = g_new + h[next_node]
                        if f_new < f[next_node]:
                            g[next_node] = g_new
                            f[next_node] = f_new
                            parent[next_node] = cur_node
            Tn.sort(key=lambda x: f[x])
            Open = Tn + Open
    if found:
        printPath(parent, stop)
        print(f'\nmin = {min}')
    else:
        print("Dell tim thay duong di")

if __name__ == "__main__":
    matrix = readmtk('input.mtk')
    h = readh('input.h')
    Branch_and_Bound(matrix, h, 0, 1)
    print(",")

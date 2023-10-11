file = "test.txt"

args = {...}
file = arg[1]
line = {}
local monitor = peripheral.find("monitor")

monitor.setTextScale(0.5)
print(monitor.getSize())
function readAllLines()
    if fs.exists(file) then
        open = fs.open(file, "r")
        num = 1
        local line = open.readLine()
        local background = open.readLine()
        local text = open.readLine()
        repeat
            monitor.setCursorPos(1,num)
            if (line ~= nil) then
                local i = 1
            for w in line:gmatch("%S+") do 
               nums =  tonumber(w)
               chars = string.char(nums)
                 monitor.blit(chars,string.sub(background, i, i),string.sub(text, i, i)) 
                 i = i + 1
                end
            
            end
            num = num + 1
            line = open.readLine()
            background = open.readLine()
            text = open.readLine()
        until line == ""
        open.close()
    end
end

repeat

    readAllLines();
    os.sleep(10000)
until false
local pad = {}
pad.x = (love.graphics.getWidth() - 70) / 2
pad.y = love.graphics.getHeight() - 20
pad.largeur = 70
pad.hauteur = 20

local balle = {}
balle.x = 0
balle.y = 0
balle.vitessex = 0
balle.vitessey = 0
balle.rayon = 10
balle.colle = false

local brique = {}
local niveau = {}

function Start()
    balle.colle = true

    niveau = {}
    local l, c

    for l = 1, 6 do -- On initialise la grille de briques --
        niveau[l] = {}
        for c = 1, 15 do
            niveau[l][c] = 1
        end
    end
end

function love.load()
    largeur = love.graphics.getWidth()
    hauteur = love.graphics.getHeight()
    brique.hauteur = 25
    brique.largeur = largeur / 15

    Start()
end

function love.draw()
    love.graphics.rectangle("fill", pad.x, pad.y, pad.largeur, pad.hauteur)
    love.graphics.circle("fill", balle.x, balle.y, balle.rayon)

    local l, c
    local bx, by = 0, 0 -- brique x / brique y --
    for l = 1, 6 do
        bx = 0
        for c = 1, 15 do
            if niveau[l][c] == 1 then
                -- On dessine la grille de briques --
                love.graphics.rectangle("fill", bx + 1, by + 1, brique.largeur - 2, brique.hauteur - 2)
            end
            bx = bx + brique.largeur
        end
        by = by + brique.hauteur
    end
end

function love.update(dt)
    pad.x = love.mouse.getX() - pad.largeur / 2 -- On centre la souris au milieu de la raquette

    if balle.colle == true then
        balle.x = pad.x + (pad.largeur / 2)
        balle.y = pad.y - balle.rayon
    else
        balle.x = balle.x + (balle.vitessex * dt)
        balle.y = balle.y + (balle.vitessey * dt)
    end

    local c = math.floor(balle.x / brique.largeur) + 1
    local l = math.floor(balle.y / brique.hauteur) + 1

    if l >= 1 and l <= #niveau and c >= 1 and c <= 15 then
        if niveau[l][c] == 1 then
            balle.vitessey = -balle.vitessey
            niveau[l][c] = 0
        end
    end
    --------------------------------------------------------TEST DE COLLISION MURS -------------------------------------------

    if balle.x > largeur then -- mur de droite
        balle.vitessex = -balle.vitessex
        balle.x = largeur -- Reposition de la balle pour éviter de traverser le mur
    end

    if balle.x < 0 then -- mur de gauche
        balle.vitessex = -balle.vitessex
        balle.x = 0
    end

    if balle.y < 0 then -- mur du haut
        balle.vitessey = -balle.vitessey
        balle.y = 0
    end

    if balle.y > hauteur then -- mur du bas (on perd)
        balle.colle = true
    end

    local posCollisionPad = pad.y - balle.rayon -- Position y a laquelle la balle peut toucher la raquette
    if balle.y > posCollisionPad then
        local dist = math.abs(pad.x - balle.x)
        if dist < pad.largeur / 2 then
            balle.vitessey = 0 - balle.vitessey
            balle.y = posCollisionPad
        end
    end
end

function love.mousepressed(x, y, n) -- prend en paramètre
    if balle.colle == true then
        balle.colle = false
        balle.vitessex = 200
        balle.vitessey = -200
    end
end

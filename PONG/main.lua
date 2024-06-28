local pad = {} -- Variable complexe
pad.x = 0 -- x = la largeur de l'écran de gauche (0) a droite (799)
pad.y = 0 -- y = la hauteur de l'écran de haut (0) en bas (599)
pad.largeur = 20 -- 20 pixels sur l'axe x
pad.hauteur = 80 -- 80 pixels sur l'axe y

local pad2 = {}
pad2.x = 0
pad2.y = 0
pad2.largeur = 20
pad2.hauteur = 80

local balle = {}
balle.x = 400
balle.y = 300
balle.largeur = 20
balle.hauteur = 20
balle.vitesse_x = 2
balle.vitesse_y = 2

score_joueur1 = 0
score_joueur2 = 0

function CentreBalle() --On initialise la balle au milieu de l'écran
    balle.x = (screen_x / 2) - balle.largeur / 2
    balle.y = (screen_y / 2) - balle.hauteur / 2
    balle.vitesse_x = 2
    balle.vitesse_y = 2
end

function Gagnant()
    if score_joueur1 == 3 then
        balle.vitesse_x = 0
        balle.vitesse_y = 0
        love.graphics.print("Joueur 1 a gagné " .. score_joueur1 .. " à " .. score_joueur2, 335, 40)
    end
    if score_joueur2 == 3 then
        balle.vitesse_x = 0
        balle.vitesse_y = 0
        love.graphics.print("Joueur 2 a gagné " .. score_joueur2 .. " à " .. score_joueur1, 335, 40)
    end
    return score_joueur1, score_joueur2
end

function love.load()
    pad.x = 0
    pad.y = love.graphics.getHeight() / 2 - 40
    pad2.x = love.graphics.getWidth() - pad2.largeur
    pad2.y = love.graphics.getHeight() / 2 - 40
    screen_x = love.graphics.getWidth()
    screen_y = love.graphics.getHeight()
    CentreBalle()
end

function love.draw()
    -- les 2 joueurs --
    love.graphics.rectangle("fill", pad.x, pad.y, pad.largeur, pad.hauteur) --"line" fait un rectangle sans remplissage, uniquement la bordure
    love.graphics.rectangle("fill", pad2.x, pad2.y, pad2.largeur, pad2.hauteur)
    --[[  love.graphics.rectangle("fill", 30, 10, 20, 80) pour les mettre côte à côte, il faut additionner la largeur du 1er rectangle (20) à sa position horizontale (10)]]
    love.graphics.rectangle("fill", balle.x, balle.y, balle.largeur, balle.hauteur)
    love.graphics.print(score_joueur1, 350, 10)
    love.graphics.print(score_joueur2, 450, 10)
    Gagnant()
end

function love.update()
    balle.x = balle.x + balle.vitesse_x
    balle.y = balle.y + balle.vitesse_y
    -- TOUCHES JOUEUR 1 --
    if love.keyboard.isDown("z") and pad.y > 0 then
        pad.y = pad.y - 2
    end
    if love.keyboard.isDown("s") and pad.y < screen_y - pad.hauteur then
        pad.y = pad.y + 2
    end

    --TOUCHES JOUEUR 2 --
    if love.keyboard.isDown("up") and pad2.y > 0 then
        pad2.y = pad2.y - 2
    end
    if love.keyboard.isDown("down") and pad2.y < screen_y - pad2.hauteur then
        pad2.y = pad2.y + 2
    end

    --REBOND DE LA BALLE DIRECTION --
    if balle.x < 0 then
        -- Perdu pour joueur 1 --
        score_joueur2 = score_joueur2 + 1
        CentreBalle()
    end
    if balle.y < 0 then
        balle.vitesse_y = -balle.vitesse_y
    end
    if balle.x > love.graphics.getWidth() - balle.largeur then
        -- Perdu pour joueur 2 --
        score_joueur1 = score_joueur1 + 1
        CentreBalle()
    end
    if balle.y > love.graphics.getHeight() - balle.hauteur then
        balle.vitesse_y = -balle.vitesse_y
    end

    -- BALLE TOUCHE RAQUETTE DE JOUEUR 1 --
    -- La balle a-t-elle atteint la raquette ?
    if balle.x <= pad.x + pad.largeur then
        -- Tester maintenant si la balle est sur la raquette ou pas
        if balle.y + balle.hauteur > pad.y and balle.y < pad.y + pad.hauteur then
            balle.vitesse_x = -balle.vitesse_x
        -- Positionne la balle au bord de la raquette
        --balle.x = pad.x + pad.largeur
        end
    end

    -- BALLE TOUCHE RAQUETTE DE JOUEUR 2 --
    if balle.x + balle.largeur > pad2.x then
        -- Tester maintenant si la balle est sur la raquette ou pas --
        if balle.y + balle.hauteur > pad2.y and balle.y < pad2.y + pad2.hauteur then
            balle.vitesse_x = -balle.vitesse_x
        end
    end
end
